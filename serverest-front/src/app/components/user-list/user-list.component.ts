import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  imports: [ CommonModule, RouterOutlet ],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  users: any[] = [];

  constructor(private apiService: ApiService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.apiService.getUsers().subscribe((response) => {
      this.users = response.usuarios;
    });
  }

  goToProducts() {
    this.router.navigate(['/products']);
  }
}
