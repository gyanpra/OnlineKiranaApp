import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Product} from '../app/Interface/product';
import { mergeMap, first, shareReplay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})


export class ProductService {

  readonly APIUrl="https://localhost:44337/api";
  readonly DeleteUrl="https://localhost:44337/api/products/";
  readonly AddUrl="https://localhost:44337/api/products/";
  readonly EditUrl="https://localhost:44337/api/products/";

  private product$: Observable<Product[]>;

  constructor(private httpclient:HttpClient) { }

  getProductList():Observable<Product[]>{
    return this.httpclient.get<any>(this.APIUrl+'/Products');
  }

  getProductById(id: number) : Observable<Product> 
    {
        return this.getProductList().pipe(mergeMap(result => result), first(Product => Product.ProductID == id));
    }

    insertProduct(newProduct : Product) :  Observable<Product> 
    {
        return this.httpclient.post<Product>(this.AddUrl, newProduct);
    }

    updateProduct(id: number, editProduct : Product) : Observable<Product>
    {
        return this.httpclient.put<Product>(this.EditUrl + id, editProduct);
    }

    deleteProduct(id: number) : Observable<any>
    {
        return this.httpclient.delete(this.DeleteUrl + id);
    }

    clearCache() 
    {
        this.product$ = null;
    }





}
