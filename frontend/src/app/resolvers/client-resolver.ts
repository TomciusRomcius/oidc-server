import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from '@angular/router';
import ClientModel from '../models/client-model';
import { inject } from '@angular/core';
import ClientService from '../services/client.service';

export const clientResolver: ResolveFn<ClientModel[]> = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
) => {
  const clientService = inject(ClientService);
  return clientService.getAll();
};
