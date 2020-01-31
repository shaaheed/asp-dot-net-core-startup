//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;
//using Comment.Application.Attributes;
//using Modules.User.Resources.Commands;
//using Modules.User.Resources.Queries;
//using Core.Application.Commands;
//using Core.Application.Queries;
//using Microsoft.AspNetCore.Mvc;
//using static Comment.Application.Constants.PermissionConstants.Operations;
//using static Comment.Application.Constants.PermissionConstants.Permission;

//namespace Module.Comment.Controllers
//{
//    //[ApiVersion("v1")]
//    [Route("api/permissions")]
//    [ApiController]
//    [Resource(PERMISSIONS)]
//    public class PermissionController : ControllerBase
//    {

//        private readonly ICommandBus _commandBus;
//        private readonly IQueryBus _queryBus;

//        public PermissionController(
//            ICommandBus commandBus,
//            IQueryBus queryBus)
//        {
//            _commandBus = commandBus;
//            _queryBus = queryBus;
//        }

//        [HttpGet("scans")]
//        [AuthorizeResource(Operation = SCAN)]
//        public async Task<ActionResult> ScanPermissions()
//        {
//            var permissions = await ScanPermissionsInternal();
//            return Ok(permissions);
//        }

//        [HttpGet("resources")]
//        [AuthorizeResource(Resource = RESOURCES, Operation = READ_LIST)]
//        public async Task<ActionResult> GetResources()
//        {
//            var q = new GetResourcesQuery();
//            var result = await _queryBus.SendAsync(q);
//            return Ok(result);
//        }

//        #region Resources Groups

//        [HttpPost("resources/groups")]
//        [AuthorizeResource(Resource = RESOURCES_GROUPS, Operation = CREATE)]
//        public async Task<ActionResult> PostResourcesGroups(CreateResourceGroupCommand command)
//        {
//            var result = await _commandBus.SendAsync(command);
//            return Ok(result);
//        }

//        [HttpGet("resources/groups")]
//        [AuthorizeResource(Resource = RESOURCES_GROUPS, Operation = READ_LIST)]
//        public async Task<ActionResult> GetResourceGroups()
//        {
//            var q = new GetResourceGroupsQuery();
//            var result = await _queryBus.SendAsync(q);
//            return Ok(result);
//        }

//        [HttpPut("resources/groups/{id}")]
//        [AuthorizeResource(Resource = RESOURCES_GROUPS, Operation = EDIT)]
//        public async Task<ActionResult> EditResourcesGroup(long id, [FromBody]EditResourceGroupsCommand command)
//        {
//            command.Id = id;
//            var result = await _commandBus.SendAsync(command);
//            return Ok(result);
//        }

//        [HttpDelete("resources/groups/{id}")]
//        [AuthorizeResource(Resource = RESOURCES_GROUPS, Operation = DELETE)]
//        public async Task<ActionResult> DeleteResourcesGroup(long id)
//        {
//            var command = new DeleteResourceGroupsCommand { Ids = new long[] { id } };
//            var result = await _commandBus.SendAsync(command);
//            return Ok(result);
//        }

//        [HttpDelete("resources/groups")]
//        [AuthorizeResource(Resource = RESOURCES_GROUPS, Operation = BULK_DELETE)]
//        public async Task<ActionResult> DeleteResourcesGroups(DeleteResourceGroupsCommand command)
//        {
//            var result = await _commandBus.SendAsync(command);
//            return Ok(result);
//        }

//        #endregion

//        [HttpPost("seeds")]
//        [AuthorizeResource(Operation = SEED)]
//        public async Task<ActionResult> SeedPermissions()
//        {
//            var permissions = await ScanPermissionsInternal();
//            var resources = new Dictionary<string, List<string>>();
//            foreach (var permission in permissions)
//            {
//                var operations = permission.Operations.Select(x => x.Operation).Distinct().ToList();
//                resources.Add(permission.Resource, operations);
//            }
//            var seedCommand = new SeedPermissionsCommand
//            {
//                Resources = resources
//            };
//            var result = await _commandBus.SendAsync(seedCommand);
//            return Ok(result);
//        }

//        private Task<List<ScanResource>> ScanPermissionsInternal()
//        {
//            return Task.Factory.StartNew(() =>
//            {

//                List<ScanResource> reaources = new List<ScanResource>();

//                var controllers = GetType().Assembly.ExportedTypes.Where(x => x.BaseType == typeof(ControllerBase));

//                foreach (var controller in controllers)
//                {
//                    var methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance);
//                    var controllerResourceName = controller.GetCustomAttribute<ResourceAttribute>()?.Name;
//                    var controllerTemplate = controller.GetCustomAttribute<RouteAttribute>()?.Template;

//                    foreach (var method in methods)
//                    {
//                        var routeAttribute = method.GetCustomAttribute<RouteAttribute>();

//                        var methodTemplate = routeAttribute?.Template;
//                        var resourceAttribute = method.GetCustomAttribute<AuthorizeResourceAttribute>();
//                        var resourceName = controllerResourceName;
//                        if (resourceAttribute != null && !string.IsNullOrEmpty(resourceAttribute.Resource))
//                        {
//                            resourceName = resourceAttribute.Resource;
//                        }

//                        if (!string.IsNullOrEmpty(resourceName)
//                        && resourceAttribute != null
//                        && !string.IsNullOrEmpty(resourceAttribute.Operation))
//                        {
//                            var scanResource = reaources.SingleOrDefault(x => x.Resource == resourceName);
//                            if (scanResource == null)
//                            {
//                                scanResource = new ScanResource();
//                                scanResource.Operations = new List<ScanResourceOperation>();
//                                scanResource.Commands = new List<ScanResourceCommand>();

//                                reaources.Add(scanResource);
//                                if (!string.IsNullOrEmpty(controllerTemplate))
//                                {
//                                    scanResource.Template = controllerTemplate + "/";
//                                }

//                            }

//                            scanResource.Resource = resourceName;

//                            var scanResourceOperation = new ScanResourceOperation
//                            {
//                                Operation = resourceAttribute.Operation
//                            };

//                            if (!string.IsNullOrEmpty(methodTemplate))
//                            {
//                                if (!string.IsNullOrEmpty(scanResource.Template))
//                                {
//                                    scanResourceOperation.Template += $"/{methodTemplate}";
//                                }
//                                else
//                                {
//                                    scanResourceOperation.Template = methodTemplate;
//                                }

//                            }
//                            scanResource.Operations.Add(scanResourceOperation);

//                            #region commands
//                            var @params = method.GetParameters();
//                            foreach (var param in @params)
//                            {
//                                var paramType = param.ParameterType;
//                                if (paramType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommand<>)))
//                                {
//                                    var command = new ScanResourceCommand();
//                                    command.Name = paramType.Name;
//                                    command.Properties = paramType.GetProperties()
//                                                        .Select(x => new ScanResourceCommandProperty
//                                                        {
//                                                            Name = x.Name,
//                                                            Type = x.PropertyType.Name
//                                                        })
//                                                        .ToList();

//                                    scanResource.Commands.Add(command);
//                                }
//                            }
//                            #endregion

//                        }


//                    }
//                }
//                return reaources;
//            });
//        }

//        private class ScanResource
//        {
//            public string Resource { get; set; }
//            public string Template { get; set; }
//            public string Synced { get; set; }
//            public ICollection<ScanResourceOperation> Operations { get; set; }
//            public ICollection<ScanResourceCommand> Commands { get; set; }

//        }

//        private class ScanResourceOperation
//        {
//            public string Synced { get; set; }
//            public string Template { get; set; }
//            public string Operation { get; set; }

//        }

//        private class ScanResourceCommand
//        {
//            public string Name { get; set; }
//            public ICollection<ScanResourceCommandProperty> Properties { get; set; }
//        }

//        private class ScanResourceCommandProperty
//        {
//            public string Name { get; set; }
//            public string Type { get; set; }

//        }
//    }
//}
