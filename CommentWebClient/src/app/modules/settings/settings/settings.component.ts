import { Component } from '@angular/core';
import { SettingsService } from './settings.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html'
})
export class SettingsComponent {

  items = [];

  constructor(
    private settingsService: SettingsService
  ) { }

  ngOnInit() {
    this.items = this.settingsService.getMenus();
  }

  goTo(nav) {
    this.settingsService.select(nav);
  }

}
