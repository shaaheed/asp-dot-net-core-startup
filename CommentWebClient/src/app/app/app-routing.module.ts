import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../components/login/login.component';
import { OrganizationsResolver } from '../modules/organizations/organizations.resolver';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    resolve: {
      organizations: OrganizationsResolver
    },
    loadChildren: () => import('../layout/default/layout-default.module').then(m => m.LayoutDefaultModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
