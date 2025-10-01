import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { TaskService, CreateTaskDto } from '../../services/task.service';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './task-form.html',
  styleUrls: ['./task-form.scss']
})
export class TaskFormComponent {
  model: CreateTaskDto = { title: '', description: '', isCompleted:false };
  

  constructor(private taskService: TaskService, private router: Router) {}

  submit() {
    this.taskService.addTask(this.model).subscribe({
      next: (res) => {
        console.log('Task created successfully:', res);
        this.router.navigate(['/tasks']);
      },
      error: (err) => {
        console.error('Error saving task', err);
      }
    });
  }
}
