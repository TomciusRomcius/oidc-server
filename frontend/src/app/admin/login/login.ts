import LoginService from '@/app/services/login.service';
import { responseToError } from '@/app/utils/api-utils';
import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-login.component',
  imports: [
    ReactiveFormsModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class LoginComponent {
  error = signal('');
  private fb = inject(FormBuilder);
  form = this.fb.group({
    username: this.fb.nonNullable.control('', {
      validators: [Validators.required, Validators.minLength(3)],
    }),
    password: this.fb.nonNullable.control('', {
      validators: [Validators.required, Validators.minLength(8)],
    }),
  });

  loginService = inject(LoginService);

  onSubmit() {
    this.form.markAllAsTouched();
    if (this.form.invalid) {
      console.log(this.form.errors);
    }
    const { username, password } = this.form.getRawValue();
    this.loginService.loginAdmin(username, password).subscribe({
      next: (token) => {

      },
      error: (res) => this.error.set(responseToError(res)),
    })
  }
}
