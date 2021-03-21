import { Component, Input, TemplateRef, ViewChild } from '@angular/core';
import { AntControlComponent } from 'src/app/shared/ant-control.component';
import { SelectControlComponent } from 'src/app/shared/select-control/select-control.component';

@Component({
  selector: 'app-button-select',
  templateUrl: './button-select.component.html'
})
export class ButtonSelectComponent extends AntControlComponent {
  
  @Input() item: any;
  @Input() clicked: boolean = false;
  @Input() labelKey: string = 'name';
  @Input() content: TemplateRef<any>;
  @ViewChild('select') select: SelectControlComponent;

  add() {
    this.clicked = true;
    setTimeout(() => this.select.setOpenState(true), 0);
  }

  onOpen(e) {
    if (!e) this.clicked = false;
  }

  onValueChanged(e) {
    const item = this.select.items.filter(x => x.id == e)[0];
    if (item) {
      this.item = item;
    }
  }

}
