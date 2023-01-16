import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IOrder } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService implements OnInit {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  getUserOrderList() {
    return this.http.get<IOrder[]>(this.baseUrl + 'orders');
  }

  getUserOrderById(id: number) {
    return this.http.get<IOrder>(this.baseUrl + `orders/${id}`);
  }
}
