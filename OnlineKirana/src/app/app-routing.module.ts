import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  
  {path: '**', redirectTo: '/home'}

  
  ];

  @NgModule({
    imports: [RouterModule.forRoot([
      {path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)},
    ])],
  exports: [RouterModule]
})


export class AppRoutingModule { }
export const routingComponents = [HomeComponent]
