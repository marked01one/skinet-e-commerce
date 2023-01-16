import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderSingleComponent } from './order-single/order-single.component';
import { OrdersRoutingModule } from './orders-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    OrderListComponent,
    OrderSingleComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    SharedModule
  ]
})
export class OrdersModule { }
