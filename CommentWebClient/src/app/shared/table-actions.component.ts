import { CommonModule } from '@angular/common';
import { Component, Input, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { SharedModule } from './shared.module';

@Component({
  selector: 'app-table-actions',
  template: `
    <ng-container>
      <ng-container *ngFor="let btn of outsideButtons">
        <ng-container *ngIf="!btn.condition || btn.condition(data)">
          <button *checkPermission="btn.permissions" nz-button (click)="btn.action(data)" class="btn-custom" [nzType]="btn.type || 'default'">
            <i nz-icon [nzType]="btn.icon"></i>
            {{btn.label|translate}}
          </button>
        </ng-container>
      </ng-container>

      <ng-container *ngIf="dropdownButtons && dropdownButtons.length > 0">
        <button nz-dropdown [nzDropdownMenu]="dropdownActions" nzTrigger="click" nz-button class="btn-custom btn-action">
          <i nz-icon nzType="ellipsis"></i>
        </button>
        <nz-dropdown-menu #dropdownActions="nzDropdownMenu">
          <ul nz-menu>
            <ng-container *ngFor="let btn of dropdownButtons">
              <li *checkPermission="btn.permissions" nz-menu-item (click)="btn.action(data)">
                <i nz-icon [nzType]="btn.icon"></i>{{btn.label|translate}}
              </li>
            </ng-container>
          </ul>
        </nz-dropdown-menu>
      </ng-container> 
    </ng-container>
    `
})
export class TableActionsComponent {

  @Input() data: any = {};
  @Input() buttons: IButton[] = [];
  dropdownButtons: IButton[] = [];
  outsideButtons: IButton[] = [];

  constructor() {
  }

  ngOnInit() {
    if (this.buttons && this.buttons.length) {
      this.buttons.forEach(btn => {
        if (btn.showAlways) {
          this.outsideButtons.push(btn);
        }
        else {
          this.dropdownButtons.push(btn);
        }
      });
    }
  }

}

@NgModule({
  declarations: [
    TableActionsComponent
  ],
  exports: [
    TableActionsComponent
  ],
  imports: [
    CommonModule,
    NzIconModule,
    NzButtonModule,
    NzDropDownModule,
    SharedModule,
    FormsModule
  ]
})
export class TableActionsModule {

}

export interface IButton {
  action: (data: any) => void
  icon?: string
  label: string
  permissions?: string[]
  showAlways?: boolean
  condition?: (data: any) => boolean,
  type?: string
}