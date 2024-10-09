import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SerService {
  url:any ="https://localhost:7207/api/Students";
  editItemId:any;
  constructor(private http:HttpClient) { }

  createItem(std:any){
    debugger
    return this.http.post<any>(this.url,std);
  }

  getAll(){
    return this.http.get<any>(this.url);
  }
  getItemById(id:any){
    this.editItemId =id;
    return this.http.get<any>(`${this.url}/${id}`)
  }

  updateItem(id:any,std:any){
    return this.http.put<any>(`${this.url}/${id}`,std)
  }

  deleteItem(id:any){
    return this.http.delete(`${this.url}/${id}`)
  }
}
