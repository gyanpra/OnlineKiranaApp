import { Injectable } from '@angular/core';
import {User} from '../Interface/user';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly APIUrl="https://localhost:44337/api";
  private product$: Observable<User[]>;
  constructor(private httpclient:HttpClient) { 
    

  }
  registerCustomer(userdetails) {
    return this.httpclient.post(this.APIUrl, userdetails);
  }
}
