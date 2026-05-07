import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '@/environments/environment';

@Injectable({ providedIn: 'root' })
export default class LoginService {
  private httpClient = inject(HttpClient);

  loginAdmin(username: string, password: string): Observable<void> {
    return this.httpClient.post<void>(`${environment.backendUrl}/admin/login`, {
      username,
      password,
    });
  }
}
