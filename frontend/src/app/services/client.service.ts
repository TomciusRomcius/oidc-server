import { environment } from '@/environments/environment';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FlowType } from '../models/client-model';

@Injectable({
  providedIn: 'root',
})
export default class ClientService {
  httpClient = inject(HttpClient);
  createClient(clientId: string, flowType: FlowType): Observable<void> {
    return this.httpClient.post<void>(`${environment.backendUrl}/client`, {
      clientId,
      oidcFlowType: flowType,
    });
  }
}
