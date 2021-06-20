import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../Interface/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  readonly APIUrl="https://localhost:44337/api/order";
  private order$: Observable<Order[]>;

  cartItemCount = 0;

  constructor(private httpclient:HttpClient) { }


    addToCart(ProductID: number){
      return this.httpclient.post<number>(this.APIUrl + `/addToCart/${ProductID}`, {});
    }
  }
