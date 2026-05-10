import { Routes } from '@angular/router';
import { LoginComponent } from './admin/login/login';
import { Clients } from './admin/clients/clients';

export const routes: Routes = [
  {
    path: 'admin/clients',
    component: Clients,
  },
  {
    path: '**',
    component: LoginComponent,
  },
];
