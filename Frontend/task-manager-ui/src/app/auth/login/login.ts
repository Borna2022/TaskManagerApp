import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class LoginComponent {
  model = { username: '', password: '' };
  loginFailed = false;

  constructor(private authService: AuthService, private router: Router) {}

  submit() {
    this.authService.login(this.model).subscribe({
      next: (res) => {
        console.log('Login success:', res);
        localStorage.setItem('token', res.token); // فرض بر اینه که API توکن برمی‌گردونه
        this.router.navigate(['/tasks']);
      },
      error: (err) => {
        console.error('Login failed:', err);
        this.loginFailed = true;
      }
    });
  }
}
