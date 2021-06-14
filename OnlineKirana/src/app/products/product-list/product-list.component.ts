import { Component, OnInit, ViewChild, TemplateRef, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Product } from 'src/app/Interface/product';
import { ProductService } from 'src/app/product.service';
import { Router } from '@angular/router';
import { DataTableDirective} from 'angular-datatables';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {

  // Add Modal
  @ViewChild('template') modal: TemplateRef<any>;

  // Update Modal
  @ViewChild('editTemplate') editmodal: TemplateRef<any>;

  selectedProduct: Product;
  products$: Observable<Product[]>;
  products: Product[] = [];
  
  //datatable property
  @ViewChild(DataTableDirective) dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  dtInstance:DataTables.Api;


  





  constructor(private _productService: ProductService,
     private router: Router) { }

  Productdisplay: Product[];



  rerender() 
  {
      this.dtElement.dtInstance?.then((dtInstance : DataTables.Api) => 
      {
          // Destroy the table first in the current context
          dtInstance.destroy();

          // Call the dtTrigger to rerender again
         this.dtTrigger.next();

      });
  }

  // Method to Delete the product
  onDelete(product: Product): void {
    this._productService.deleteProduct(product.productID).subscribe(result => {
      this._productService.clearCache();
      this.products$ = this._productService.getProductList();
      this.products$.subscribe(newlist => {
        this.products = newlist;

        this.rerender();
      })
    })
  }

  // We will use this method to destroy old table and re-render new table

  onSelect(product: Product): void {
    this.selectedProduct = product;

    this.router.navigateByUrl("/products/" + product.productID);
  }

  
  
  
  ngOnInit(): void {
    this._productService.getProductList()
      .subscribe(
        data => {
          this.Productdisplay = data;
        }
      );
  }

  ngOnDestroy() {
    // Do not forget to unsubscribe
    this.dtTrigger.unsubscribe();
  }
}

