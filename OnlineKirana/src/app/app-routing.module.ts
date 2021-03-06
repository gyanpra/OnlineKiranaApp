import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Component/home/home.component';
import { LoginComponent } from './Component/login/login.component';


const routes: Routes = [
  
  {path: '**', redirectTo: '/home'},
  {path: 'login', redirectTo: '/login'}
  


  
  ];

  @NgModule({
    imports: [RouterModule.forRoot([
      {path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)},
    ])],
  exports: [RouterModule]
})


export class AppRoutingModule { }
export const routingComponents = [HomeComponent]
