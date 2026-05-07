import { Routes } from '@angular/router';
import { LoginComponent } from './admin/login/login';

export const routes: Routes = [
  {
    path: '**',
    component: LoginComponent,
  },
];
