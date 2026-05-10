import { Routes } from '@angular/router';
import { LoginComponent } from './admin/login/login';
import { Clients as CreateClient } from './admin/create-client/create-client';
import { ViewClients } from './admin/view-clients/view-clients';
import { clientResolver } from './resolvers/client-resolver';

export const routes: Routes = [
  {
    path: 'admin/clients',
    component: ViewClients,
    resolve: {
      clients: clientResolver,
    },
    runGuardsAndResolvers: 'always',
    children: [
      {
        path: 'create',
        component: CreateClient,
      },
    ],
  },
  {
    path: '**',
    component: LoginComponent,
  },
];
