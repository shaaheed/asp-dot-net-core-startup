import {
    Injectable,
    ComponentFactoryResolver,
    ApplicationRef,
    Injector,
    EmbeddedViewRef,
    ComponentRef
} from '@angular/core';

@Injectable()
export class DynamicDomService {

    constructor(
        private componentFactoryResolver: ComponentFactoryResolver,
        private appRef: ApplicationRef,
        private injector: Injector
    ) { }

    append(component: any, domRef: HTMLElement) {

        // 1. Create a component reference from the component
        const componentRef = this.componentFactoryResolver
            .resolveComponentFactory(component)
            .create(this.injector);

        // 2. Attach component to the appRef so that it's inside the ng component tree
        this.appRef.attachView(componentRef.hostView);

        // 3. Get DOM element from component
        const domElem = (componentRef.hostView as EmbeddedViewRef<any>).rootNodes[0] as HTMLElement;

        // 4. Append DOM element to the body
        domRef.appendChild(domElem);

        return componentRef;

        // 5. Wait some time and remove it from the component tree and from the DOM
        // setTimeout(() => {
        //     this.appRef.detachView(componentRef.hostView);
        //     componentRef.destroy();
        // }, 3000);
    }

    render(component, domRefId) {
        return this.append(component, document.getElementById(domRefId));
    }

    destroy<C>(componentRef: ComponentRef<C>) {
        this.appRef.detachView(componentRef.hostView);
        componentRef.destroy();
    }
}