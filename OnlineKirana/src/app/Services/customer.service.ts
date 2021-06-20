import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  readonly APIUrl="https://localhost:44337/api/";

  constructor(private httpclient:HttpClient) {

   }

}
