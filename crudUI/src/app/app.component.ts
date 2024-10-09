import { Component } from '@angular/core';
import { SerService } from './ser.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'crudUI';
  allData:any;
  createFrom:boolean=false;
  userDetails:boolean=true;
  formData: any = {};
  editItem:any;
  constructor(private service:SerService){}
  ngOnInit():void{
    this.service.getAll().subscribe(
      (res)=>{this.allData=res},
      (err)=>{console.log(err)}
    )
  }

  deleteOneItem(id:any){
    this.service.deleteItem(id).subscribe(
      (res)=>{
        console.log(res)
        window.location.reload();
      },
      (err)=>console.log(err)
    )
  }

  createNew(){
    this.createFrom=true;
    this.userDetails=false
  }
  closeForm(){
    this.createFrom=false;
    this.userDetails=true;
  }
  onSubmit(form: any): void {
      this.service.createItem(form).subscribe((result)=>{
        console.log(result)
      })
      console.log('Form submitted:', this.formData);
      form.resetForm();
      this.formData = {};
    }
    edit(id:any){
      this.service.getItemById(id).subscribe((res)=>{
        this.editItem =id
        console.log(res)
      })
    }
    editData(value:any){
      this.service.updateItem(this.editItem,value).subscribe((res)=>{
        window.location.reload();
      })
    }
}
