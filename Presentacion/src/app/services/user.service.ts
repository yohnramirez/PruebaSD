import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { User } from '../models/user.model.js'

@Injectable({
  providedIn: 'root'
})

/**
 * Definición del servicio de usuarios
 */
export class UserService {

  /**
   *Definición del enpoint para obtener todos los usuarios
  */
  private domain = "https://localhost:44391";

  /**
   * Constructor
  */
  constructor(private http: HttpClient) { }

  /**
   * Método que obtiene todos los usuarios
  */
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.domain}/api/User/GetAllUsers`);
  }

  /**
   * Método que guarda un usuario
  */
  saveUser(user: User): Observable<void> {
    return this.http.post<void>(`${this.domain}/api/User/SaveUser`, user).pipe(
      catchError(this.handleError)
    )
  }

  /**
   * Método que modifica un usuario
  */
  updateUser(user: User): Observable<void> {
    return this.http.put<void>(`${this.domain}/api/User/UpdateUser`, user).pipe(
      catchError(this.handleError)
    );
  }

  /**
   * Método que elimina un usuario
  */
  deleteUser(userId: number): Observable<void> {
    return this.http.delete<void>(`${this.domain}/api/User/DeleteUser?userId=${userId}`).pipe(
      catchError(this.handleError)
    );
  }

  /**
   * Método gestiona los errores
  */
  private handleError(error: any): Observable<never> {
    console.error('Error:', error);
    throw error;
  }
}
