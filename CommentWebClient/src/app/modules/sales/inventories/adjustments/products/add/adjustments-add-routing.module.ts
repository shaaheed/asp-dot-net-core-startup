import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InventoryAdjustmentAddComponent } from './adjustment-add.component';

const routes: Routes = [
  { path: '', component: InventoryAdjustmentAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryAdjustmentAddRoutingModule { }
