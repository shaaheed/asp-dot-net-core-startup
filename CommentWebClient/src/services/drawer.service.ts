import { Injectable } from '@angular/core';
import { NzDrawerRef, NzDrawerService } from 'ng-zorro-antd/drawer';

@Injectable()
export class DrawerService {

    private _drawerRef: NzDrawerRef<any, any> = null;
    private _extra: any = null;

    constructor(
        private drawerService: NzDrawerService
    ) { }

    async open(module: Promise<unknown>, component: Promise<unknown>, extra?: any) {
        this._extra = extra;
        module.then(m => {
            component.then(c => {
                const componentName = Object.keys(c)[0];
                this._drawerRef = this.drawerService.create({
                    nzContent: c[componentName],
                    nzWrapClassName: 'app-right-drawer',
                    // nzMask: false,
                    nzWidth: 400,
                    nzClosable: false,
                    nzBodyStyle: { padding: 0 },
                    nzMaskClosable: true,
                    nzMaskStyle: { backgroundColor: 'transparent' }
                });

                // this._drawerRef.afterOpen.subscribe(() => {
                //     const instance = this._drawerRef.getContentComponent();
                //     if (instance?.registerOnDrawerClose) {
                //         instance.registerOnDrawerClose(() => {
                //             this.close();
                //         });
                //     }
                // });
            });
        });
    }

    close() {
        if (this._drawerRef) {
            this._drawerRef.close();
        }
    }

    getExtra(): any {
        return this._extra;
    }

}