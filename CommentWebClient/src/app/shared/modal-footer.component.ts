import { Component, NgModule, Output, TemplateRef, ViewChild } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { NzIconModule } from 'ng-zorro-antd/icon';

@Component({
  selector: 'app-modal-footer',
  template: `
    <div class="ant-modal-content">
      <div class="ant-modal-body">
          <div class="ant-modal-confirm-body-wrapper">
              <div class="ant-modal-confirm-body">
                  <i class="anticon anticon-question-circle"></i>
                  <span class="ant-modal-confirm-title">
                      <span class="ng-star-inserted">নিশ্চিত করুন</span>
                  </span>
                  <div class="ant-modal-confirm-content">
                      <div class="ng-star-inserted">আপনি কি সত্যিই মুছে ফেলতে চান?</div>
                  </div>
              </div>
              <div class="ant-modal-confirm-btns">
                  <button class="ant-btn ng-star-inserted">
                      <span class="ng-star-inserted">Cancel</span>
                  </button>
                  <button class="ant-btn ant-btn-primary ng-star-inserted">
                      <span class="ng-star-inserted">OK</span>
                  </button>
              </div>
          </div>
      </div>
    </div>
    `
})
export class ModalFooterComponent {

  @Output() onOk: boolean = false;
  @Output() onCancel: boolean = false;

  constructor() {
  }

}

@NgModule({
  declarations: [
    ModalFooterComponent
  ],
  exports: [
    ModalFooterComponent
  ],
  imports: [
    NzIconModule,
    TranslateModule
  ]
})
export class ModalFooterModule {

}