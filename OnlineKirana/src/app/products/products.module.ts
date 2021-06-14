import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductsRoutingModule } from './products-routing.module';
import { DataTablesModule } from 'angular-datatables';


@NgModule({
  declarations: [
    ProductDetailsComponent,
    ProductListComponent
  ],
  exports:[ProductDetailsComponent,ProductListComponent],
  imports: [
    CommonModule,
    FormsModule,
    ProductsRoutingModule,
    ReactiveFormsModule,
    DataTablesModule,
  ],
  
})

export class ProductsModule { }
