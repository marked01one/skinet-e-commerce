import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  orderList: IOrder[];

  constructor(private orderListService: OrdersService) { }

  ngOnInit(): void {
    this.getUserOrderList();
  }

  getUserOrderList() {
    this.orderListService.getUserOrderList().subscribe(response => {
      this.orderList = response;
    }, error => {
      console.log(error);
    })
  }
}
