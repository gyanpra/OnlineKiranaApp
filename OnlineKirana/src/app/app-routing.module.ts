import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [


  
  ];

  @NgModule({
    imports: [RouterModule.forRoot([
      {path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)},
    //{path: 'products', loadChildren: 'src/app/products/products.module#ProductsModule'},
    {path: '**', redirectTo: '/products'}
    ])],
  exports: [RouterModule]
})


export class AppRoutingModule { }
