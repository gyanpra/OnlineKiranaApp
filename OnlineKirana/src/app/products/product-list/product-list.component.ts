import { Component, OnInit, ViewChild, TemplateRef, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Product } from 'src/app/Interface/product';
import { ProductService } from 'src/app/product.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Observable, Subject } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {

  // For the FormControl - Adding products
  InsertForm: FormGroup;
  ProductName: FormControl;
  Category: FormControl;
  Brand: FormControl;
  Price: FormControl;
  ProductImage: FormControl;
  QuantityOnHand: FormControl;
  ReOrderLevel: FormControl;

  // Updating the Product
  UpdateForm: FormGroup;
  _ProductID: FormControl;
  _ProductName: FormControl;
  _Category: FormControl;
  _Brand: FormControl;
  _Price: FormControl;
  _ProductImage: FormControl;
  _QuantityOnHand: FormControl;
  _ReOrderLevel: FormControl;


  // Add Modal
  @ViewChild('template') modal: TemplateRef<any>;

  // Update Modal
  @ViewChild('editTemplate') editmodal: TemplateRef<any>;


  modalMessage: string;
  selectedProduct: Product;
  modalRef: BsModalRef;
  products$: Observable<Product[]>;
  products: Product[] = [];

  //datatable property
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement: DataTableDirective;





  constructor(private _productService: ProductService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private chRef: ChangeDetectorRef,
    private router: Router) { }

  Productdisplay: Product[];

  /// Load Add New product Modal
  onAddProduct() {
    this.modalRef = this.modalService.show(this.modal);
  }

  // Method to Add new Product
  onSubmit() {
    let newProduct = this.InsertForm.value;

    this._productService.insertProduct(newProduct).subscribe(
      result => {
        this._productService.clearCache();
        this.products$ = this._productService.getProductList();

        this.products$.subscribe(newlist => {
          this.products = newlist;
          this.modalRef.hide();
          this.InsertForm.reset();
          this.rerender();

        });
        console.log("New Product added");

      },
      error => console.log('Unable to add new Product')

    )

  }

  rerender() {
    this.dtElement.dtInstance?.then((dtInstance: DataTables.Api) => {
      // Destroy the table first in the current context
      dtInstance.destroy();

      // Call the dtTrigger to rerender again
      this.dtTrigger.next();

    });
  }


  // Update an Existing Product
  onUpdate() {
    let editProduct = this.UpdateForm.value;
    this._productService.updateProduct(editProduct.id, editProduct).subscribe(
      result => {
        console.log('Product Updated');
        this._productService.clearCache();
        this.products$ = this._productService.getProductList();
        this.products$.subscribe(updatedlist => {
          this.products = updatedlist;

          this.modalRef.hide();
          this.rerender();
        });
      },
      error => console.log('Could Not Update Product')
    )
  }

  onUpdateModal(productEdit: Product): void {
    this._ProductID.setValue(productEdit.ProductID);
    this._ProductName.setValue(productEdit.ProductName);
    this._Category.setValue(productEdit.Category);
    this._Brand.setValue(productEdit.Brand);
    this._Price.setValue(productEdit.Price);
    this._ProductImage.setValue(productEdit.ProductImage);
    this._QuantityOnHand.setValue(productEdit.QuantityOnHand);
    this._ReOrderLevel.setValue(productEdit.ReOrderLevel);

    this.UpdateForm.setValue({
      'ProductID': this._ProductID.value,
      'ProductName': this._ProductName.value,
      'Category': this._Category.value,
      'Brand': this._Brand.value,
      'Price': this._Price.value,
      'ProductImage': this._ProductImage.value,
      'QuantityOnHand': this._QuantityOnHand.value,
      'ReOrderLevel': this._ReOrderLevel.value

    });

    this.modalRef = this.modalService.show(this.editmodal);

  }



  // Method to Delete the product
  onDelete(product: Product): void {
    this._productService.deleteProduct(product.ProductID).subscribe(result => {
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

    this.router.navigateByUrl("/products/" + product.ProductID);
  }






  ngOnInit(): void {

    this._productService.getProductList()
      .subscribe(
        data => {
          this.Productdisplay = data;
        }
      );

    // Modal Message
    this.modalMessage = "All Fields Are Mandatory";

    // Initializing Add product properties


    this.ProductName = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this.Category = new FormControl('', [Validators.required, Validators.min(0), Validators.max(50)]);
    this.Brand = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this.Price = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this.QuantityOnHand = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this.ReOrderLevel = new FormControl('', [Validators.required, Validators.maxLength(150)]);

    this.InsertForm = this.fb.group({

      'ProductName': this.ProductName,
      'Category': this.Category,
      'Brand': this.Brand,
      'Price': this.Price,
      'ProductImage': this.ProductImage,
      'QuantityOnHand': this.QuantityOnHand,
      'ReOrderLevel': this.ReOrderLevel,

    });
    this._ProductID = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this._ProductName = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this._Category = new FormControl('', [Validators.required, Validators.min(0), Validators.max(50)]);
    this._Brand = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this._Price = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this._QuantityOnHand = new FormControl('', [Validators.required, Validators.maxLength(50)]);
    this._ReOrderLevel = new FormControl('', [Validators.required, Validators.maxLength(150)]);

    this.UpdateForm = this.fb.group({

      'ProductID': this._ProductID,
      'ProductName': this._ProductName,
      'Category': this._Category,
      'Brand': this._Brand,
      'Price': this._Price,
      'ProductImage': this._ProductImage,
      'QuantityOnHand': this._QuantityOnHand,
      'ReOrderLevel': this._ReOrderLevel,

    });
  }


  ngOnDestroy() {
    // Do not forget to unsubscribe
    this.dtTrigger.unsubscribe();
  }
}

