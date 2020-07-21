import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full'
  },
  {
    path: '',
    children: [
      {
        path: 'auth',
        loadChildren: () => import("./account/account.module").then(m => m.AccountModule)
      },
      {
        path: 'service',
        loadChildren: () => import('./services/services.module').then(m => m.ServicesModule)
      }
    ]
  },
  { path: 'auth-callback', component: AuthCallbackComponent },
  // Fallback when no prior route is matched
  { path: '**', redirectTo: '/auth/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
