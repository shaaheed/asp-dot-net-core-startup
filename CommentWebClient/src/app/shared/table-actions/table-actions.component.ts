import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { ButtonConfig } from '../button.config';

@Component({
  selector: 'app-table-actions',
  templateUrl: './table-actions.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TableActionsComponent {

  @Input() data: any = {};
  @Input() buttons: ButtonConfig[] = [];
  dropdownButtons: ButtonConfig[] = [];
  outsideButtons: ButtonConfig[] = [];

  constructor() {}

  ngOnInit() {
    if (this.buttons && this.buttons.length) {
      const showAlways = this.buttons.length <= 3;
      this.buttons.forEach(btn => {
        if (showAlways || btn.showAlways) {
          this.outsideButtons.push(btn);
        }
        else {
          this.dropdownButtons.push(btn);
        }
      });
    }
  }

}
