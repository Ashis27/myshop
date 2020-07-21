import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService as AuthGuard } from '../shared/authentication/auth.guard';
import { RoleGuardService as RoleGuard } from '../shared/authentication/role.guard';
import { AppLayoutComponent } from '../shared/components/app-layout.component';
import { CatalogComponent } from './catalog/catalog.component';
import { BasketComponent } from './basket/basket.component';

const routes: Routes = [
  {
    path: '',
    //component: AppLayoutComponent,
    // canActivate: [AuthGuard],
    children: [
      {
        path: 'catalog',
        component: CatalogComponent,
        // canActivate:[RoleGuard],
        // data:{
        //   roles:[]
        // }
      },
      {
        path: 'basket',
        component: BasketComponent,
        // canActivate:[RoleGuard],
        // data:{
        //   roles:[]
        // }
      }
    ]

  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class ServicesRoutingModule { }
