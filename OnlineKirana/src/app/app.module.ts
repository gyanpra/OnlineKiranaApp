import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DataTablesModule } from 'angular-datatables';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {ProductService} from './product.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { ProductsModule } from './products/products.module';
import { UploadImageComponent } from './upload-image/upload-image.component';
import { UserComponent } from './Component/user/user.component';
import { ProductComponent } from './Component/product/product.component';
import { SearhBarComponent } from './Component/product/searh-bar/searh-bar.component';
import { CartComponent } from './Component/product/cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadImageComponent,
    UserComponent,
    ProductComponent,
    SearhBarComponent,
    CartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ProductsModule,
    DataTablesModule,
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
