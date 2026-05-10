import ClientModel from '@/app/models/client-model';
import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatButton } from '@angular/material/button';
import { Page } from '@/app/shared/page/page';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow,
  MatRowDef,
  MatTable,
} from '@angular/material/table';

@Component({
  selector: 'app-view-clients',
  imports: [
    Page,
    MatButton,
    MatTable,
    MatColumnDef,
    MatHeaderCell,
    MatCell,
    MatHeaderRow,
    MatRow,
    MatHeaderCellDef,
    MatCellDef,
    MatHeaderRowDef,
    MatRowDef,
  ],
  templateUrl: './view-clients.html',
  styleUrl: './view-clients.css',
})
export class ViewClients {
  route = inject(ActivatedRoute);
  clients = signal<ClientModel[]>(this.route.snapshot.data['clients']);
  displayedColumns = ['clientId', 'actions'];
  constructor() {
    this.route.data.subscribe((data) => this.clients.set(data['clients'] as ClientModel[]));
  }
}
