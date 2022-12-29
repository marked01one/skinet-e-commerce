import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/products';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'SkiNET';

  products: IProduct[];

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/products?pageSize=50')
        .subscribe((response: IPagination) => {
      this.products = response.data;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
