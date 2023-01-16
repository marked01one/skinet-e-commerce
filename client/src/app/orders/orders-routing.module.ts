import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderSingleComponent } from './order-single/order-single.component';


const routes: Routes = [
  {path: '', component: OrderListComponent},
  {path: ':id', component: OrderSingleComponent, data: {breadcrumb: {alias: 'orderSingle'}}}

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
