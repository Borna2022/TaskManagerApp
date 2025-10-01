import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrls: ['./register.scss']
})
export class RegisterComponent {
  model = { username: '', password: '', email: '' };
  registerFailed = false;
  registerSuccess = false;

  constructor(private authService: AuthService, private router: Router) {}

  submit() {
    this.authService.register(this.model).subscribe({
      next: (res) => {
        console.log('Register success:', res);
        this.registerSuccess = true;
        // بعد از ثبت‌نام موفق می‌تونی مستقیم به لاگین هدایت کنی
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Register failed:', err);
        this.registerFailed = true;
      }
    });
  }
}
