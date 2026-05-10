import { environment } from '@/environments/environment';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ClientModel, { FlowType } from '../models/client-model';
import ApiResponseModel from '../models/api-response.model';
import { responseToModel } from '../utils/api-utils';

@Injectable({
  providedIn: 'root',
})
export default class ClientService {
  httpClient = inject(HttpClient);
  getAll(): Observable<ClientModel[]> {
    return responseToModel(
      this.httpClient.get<ApiResponseModel<ClientModel[]>>(`${environment.backendUrl}/client`),
    );
  }

  createClient(clientId: string, flowType: FlowType): Observable<void> {
    return this.httpClient.post<void>(`${environment.backendUrl}/client`, {
      clientId,
      oidcFlowType: flowType,
    });
  }
}
