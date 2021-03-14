// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-create-product',
//   templateUrl: './create-product.component.html',
//   styleUrls: ['./create-product.component.css']
// })
// export class CreateProductComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }


import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ProductServiceProxy,
  CreateProductInput,
  
} from '@shared/service-proxies/service-proxies';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product = new CreateProductInput();
  
  checkedRolesMap: { [key: string]: boolean } = {};
  defaultRoleCheckedStatus = false;
  

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
   
    // this._userService.getRoles().subscribe((result) => {
    //   this.roles = result.items;
    //   this.setInitialRolesStatus();
    // });
  }

  // setInitialRolesStatus(): void {
  //   _map(this.roles, (item) => {
  //     this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
  //       item.normalizedName
  //     );
  //   });
  // }

  // isRoleChecked(normalizedName: string): boolean {
  //   // just return default role checked status
  //   // it's better to use a setting
  //   return this.defaultRoleCheckedStatus;
  // }

  // onRoleChange(role: RoleDto, $event) {
  //   this.checkedRolesMap[role.normalizedName] = $event.target.checked;
  // }

  // getCheckedRoles(): string[] {
  //   const roles: string[] = [];
  //   _forEach(this.checkedRolesMap, function (value, key) {
  //     if (value) {
  //       roles.push(key);
  //     }
  //   });
  //   return roles;
  // }

  // save(): void {
  //   this.saving = true;

  //   this.user.roleNames = this.getCheckedRoles();

  //   this._userService
  //     .create(this.user)
  //     .pipe(
  //       finalize(() => {
  //         this.saving = false;
  //       })
  //     )
  //     .subscribe(() => {
  //       this.notify.info(this.l('SavedSuccessfully'));
  //       this.bsModalRef.hide();
  //       this.onSave.emit();
  //     });
  // }

  save(): void {
    this.saving = true;
    this._productService
      .createProduct(this.product)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}