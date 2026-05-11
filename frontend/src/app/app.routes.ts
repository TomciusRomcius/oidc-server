import { Routes } from '@angular/router';
import { LoginComponent } from './admin/login/login';
import { ViewClients } from './admin/view-clients/view-clients';
import { clientResolver } from './resolvers/client-resolver';
import { UpsertClient } from './admin/upsert-client/upsert-client';

export const routes: Routes = [
  {
    path: 'admin/clients',
    pathMatch: 'full',
    component: ViewClients,
    resolve: {
      clients: clientResolver,
    },
    runGuardsAndResolvers: 'always',
  },
  {
    path: 'admin/clients/create',
    component: UpsertClient,
  },
  {
    path: 'admin/clients/edit/:clientId',
    component: UpsertClient,
  },
  {
    path: '**',
    component: LoginComponent,
  },
];
