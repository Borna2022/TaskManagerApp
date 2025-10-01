import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideRouter, Routes } from '@angular/router';
import { importProvidersFrom } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app/app';
import { LoginComponent } from './app/auth/login/login';
import { RegisterComponent } from './app/auth/register/register';
import { TaskListComponent } from './app/tasks/task-list/task-list';
import { TaskFormComponent } from './app/tasks/task-form/task-form';
import { authInterceptor } from './app/services/auth.interceptor';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'tasks', component: TaskListComponent },
  { path: 'tasks/new', component: TaskFormComponent },
  { path: '', redirectTo: 'tasks', pathMatch: 'full' }
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    importProvidersFrom(FormsModule),
    provideHttpClient(
      withInterceptors([authInterceptor])   // ✅ اینجا فانکشن رو پاس می‌دی
    )
  ]
}).catch(err => console.error(err));
