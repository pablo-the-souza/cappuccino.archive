import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ArchiveService } from '../archive.service';

@Component({
  selector: 'app-archive-form',
  templateUrl: './archive-form.component.html',
  styleUrls: ['./archive-form.component.css']
})
export class ArchiveFormComponent implements OnInit {
  update: String;
  selectedOption: number; 
  categories: Observable<any>; 
  records : Observable<any>; 
  isAddingCategory : boolean; 

  constructor(public service: ArchiveService) { }

  ngOnInit(): void {
    this.isAddingCategory = false; 
    this.resetForm();
    this.records = this.service.getFilesForForm();
    this.categories = this.service.getBoxes();

    this.service.boxFormData = {
      id: "",
      name: ""
    }
  }



  onSubmit(form: NgForm) {
    console.log(form.value)
    if (this.service.formData.id == "")
      this.insertRecord(form)
    else 
      this.updateRecord(form)
  }

  insertRecord(form: NgForm) {
    console.log("I'm categoryID = " + form.value.categoryId)
    this.service.postRecordDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.getRecords();
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.service.formData = {
      id: 0,
      date: new Date,
      name: "",
      value: 0,
      categoryId: 0, 
      type: ""
    }
  }


  updateCategory(event: any) {
    this.service.formData.categoryId = this.selectedOption;
  }

  updateRecord(form: NgForm) {
    this.service.putRecordDetail().subscribe(
      res => {
        console.log("Update ok")
        this.resetForm(form);
        this.service.getRecords();
      },
      err => {
        console.log(err);
        
      }
    );
  }

  changeIsAddingCategory(){
    this.isAddingCategory = true; 
  }

  insertCategory(categoryForm: NgForm){
    this.isAddingCategory = false; 
    this.service.postCategory().subscribe(
      res => {
        console.log("Category Inserted")
        this.categories = this.service.getCategories();
      },
      err => {
        console.log(err);
      }
    );
  }


}
