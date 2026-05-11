import { Component, inject, signal } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatSelect, MatOption } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import ClientService from '@/app/services/client.service';
import { responseToError } from '@/app/utils/api-utils';
import { FlowType } from '@/app/models/client-model';
import { Page } from '@/app/shared/page/page';

@Component({
  selector: 'app-clients',
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatLabel,
    MatSelect,
    MatOption,
    MatInput,
    MatButton,
    MatError,
    Page,
  ],
  templateUrl: './upsert-client.html',
  styleUrl: './upsert-client.css',
})
export class UpsertClient {
  private clientService = inject(ClientService);
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  form = this.fb.group({
    clientId: this.fb.nonNullable.control('', {
      validators: [Validators.required, Validators.maxLength(32)],
    }),
    flowType: this.fb.nonNullable.control<FlowType>(FlowType.ImplicitFlow),
  });
  error = signal('');
  isEditMode = signal(false);

  FlowType = FlowType;

  constructor() {
    const clientId = this.route.snapshot.paramMap.get('clientId');
    if (clientId) {
      this.isEditMode.set(true);
      this.form.get('clientId')?.disable();
      this.handlePatchForm(clientId);
    }
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const { clientId, flowType } = this.form.getRawValue();

    if (this.isEditMode()) {
      this.clientService.updateClient(clientId, flowType).subscribe({
        next: () => this.router.navigate(['/admin/clients']),
        error: (res) => this.error.set(responseToError(res)),
      });
    } else {
      this.clientService.createClient(clientId, flowType).subscribe({
        next: () => this.router.navigate(['/admin/clients']),
        error: (res) => this.error.set(responseToError(res)),
      });
    }
  }

  private handlePatchForm(clientId: string) {
    this.clientService.getOne(clientId).subscribe((existingClient) => {
      if (existingClient) {
        this.form.patchValue({
          clientId: existingClient.clientId,
          flowType: existingClient.oidcFlowType,
        });
      } else {
        this.error.set('Client not found');
      }
    });
  }
}
