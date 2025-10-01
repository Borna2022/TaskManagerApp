import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Task {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private baseUrl = 'https://localhost:7068/api/Task'; // آدرس API بک‌اند

  constructor(private http: HttpClient) {}

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl);
  }

  getTask(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.baseUrl}/${id}`);
  }

  // addTask(task: Task): Observable<Task> {
  //   return this.http.post<Task>(this.baseUrl, task);
  // }
  addTask(task: CreateTaskDto): Observable<Task> {
    return this.http.post<Task>(this.baseUrl, task);
  }

  updateTask(task: Task): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${task.id}`, task);
  }

  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
export interface Task {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
}

// DTO برای ایجاد تسک جدید
export interface CreateTaskDto {
  isCompleted:boolean;
  title: string;
  description: string;
}

