import { Component, inject, signal } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatSelect, MatOption } from '@angular/material/select';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { FlowType } from '@/app/models/client-model';
import ClientService from '@/app/services/client.service';
import { responseToError } from '@/app/utils/api-utils';

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
    MatError
],
  templateUrl: './clients.html',
  styleUrl: './clients.css',
})
export class Clients {
  private clientService = inject(ClientService);
  private fb = inject(FormBuilder);
  form = this.fb.group({
    clientId: this.fb.nonNullable.control('', {
      validators: [Validators.required, Validators.maxLength(32)],
    }),
    flowType: this.fb.nonNullable.control<FlowType>(FlowType.ImplicitFlow),
  });
  error = signal('');

  FlowType = FlowType;

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const { clientId, flowType } = this.form.getRawValue();
    this.clientService.createClient(clientId, flowType).subscribe({
      next: () => console.log('Success'),
      error: (res) => this.error.set(responseToError(res)),
    });
  }
}
