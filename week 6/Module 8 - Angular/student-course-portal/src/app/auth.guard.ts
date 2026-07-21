import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean {
    const isLoggedIn = localStorage.getItem('token') !== null;
    if (!isLoggedIn) {
      console.warn('Blocked: routing guard requires login token.');
      return false;
    }
    return true;
  }
}