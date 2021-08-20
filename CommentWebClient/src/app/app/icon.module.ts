import { NgModule } from '@angular/core';
import { IconDefinition } from '@ant-design/icons-angular';
import { NzIconModule } from 'ng-zorro-antd/icon';
import {
  DownOutline,
  SearchOutline,
  NotificationOutline,
  SettingOutline,
  CaretDownOutline,
  ProfileOutline,
  LogoutOutline,
  HomeOutline,
  AppstoreOutline,
  GiftOutline,
  BarChartOutline,
  UserOutline,
  PlusCircleOutline,
  SyncOutline,
  FilterOutline,
  EllipsisOutline,
  EditOutline,
  LoadingOutline,
  ArrowLeftOutline,
  PrinterOutline,
  ThunderboltOutline,
  CloseOutline,
  CloseCircleOutline,
  UploadOutline,
  DownloadOutline,
  QuestionCircleOutline,
  ShoppingOutline,
  TeamOutline,
  SafetyOutline,
  BankOutline
} from '@ant-design/icons-angular/icons';

const icons: IconDefinition[] = [
  DownOutline,
  SearchOutline,
  NotificationOutline,
  SettingOutline,
  CaretDownOutline,
  ProfileOutline,
  LogoutOutline,
  HomeOutline,
  AppstoreOutline,
  GiftOutline,
  BarChartOutline,
  UserOutline,
  PlusCircleOutline,
  SyncOutline,
  FilterOutline,
  EllipsisOutline,
  EditOutline,
  LoadingOutline,
  ArrowLeftOutline,
  PrinterOutline,
  ThunderboltOutline,
  CloseOutline,
  CloseCircleOutline,
  UploadOutline,
  DownloadOutline,
  QuestionCircleOutline,
  ShoppingOutline,
  TeamOutline,
  SafetyOutline,
  BankOutline
];

@NgModule({
  imports: [
    NzIconModule.forChild(icons)
  ]
})
export class IconModule {

}
