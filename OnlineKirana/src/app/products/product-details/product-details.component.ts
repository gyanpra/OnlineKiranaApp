import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/Interface/product';
import { ProductService } from 'src/app/Services/product.service';
import { OrderService } from 'src/app/Services/order.service';
import { Order } from 'src/app/Interface/order';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  @Input() product : Product;
  @Input() productID: number;
  

  constructor(
    private route: ActivatedRoute, 
    private OrderService: OrderService,
    private router : Router, 
    private productservice: ProductService ) { }

    

  ngOnInit() {
    let id = + this.route.snapshot.params['id'];

    this.productservice.getProductById(id).subscribe(result => this.product = result);
    
}
addToCart() {
  this.OrderService.addToCart(this.productID).subscribe(
    result => {
      console.log('One Item added to cart');
    }, error => {
      console.log('Error ocurred while adding to cart : ', error);
    });
  }
}
