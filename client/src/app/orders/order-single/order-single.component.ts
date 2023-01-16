import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-order-single',
  templateUrl: './order-single.component.html',
  styleUrls: ['./order-single.component.scss']
})
export class OrderSingleComponent implements OnInit {
  order: IOrder;

  constructor(
    private orderListService: OrdersService,
    private bcService: BreadcrumbService,
    private activatedRoute: ActivatedRoute
  ) {
    this.bcService.set('@orderSingle', ' ');
  }

  ngOnInit(): void {
    this.loadUserOrderById();
  }
  loadUserOrderById() {
    this.orderListService.getUserOrderById(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(order => {
        this.order = order;
        this.bcService.set('@orderSingle', 'Order ' + this.order.id + ' - ' + this.order.status);
      });
  }

}
