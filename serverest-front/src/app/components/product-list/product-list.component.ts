import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-product-list',
  imports: [ CommonModule, RouterOutlet ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: any[] = [];
  isLoading = true;
  errorMessage = '';

  constructor(private apiService: ApiService,
    private router: Router
  ) {}

  ngOnInit() {
    this.apiService.getProducts().subscribe({
      next: (data) => {
        this.products = data.produtos;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Erro ao buscar produtos:', error);
        this.errorMessage = 'Erro ao carregar produtos. Tente novamente.';
        this.isLoading = false;
      }
    });
  }

  goToUsers() {
    this.router.navigate(['/']);
  }
}
