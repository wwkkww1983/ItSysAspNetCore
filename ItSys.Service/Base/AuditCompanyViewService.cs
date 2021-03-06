﻿using AutoMapper;
using ItSys.Common;
using ItSys.Dto;
using ItSys.Entity;
using ItSys.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItSys.Service
{
    /// <summary>
    /// 审计及所属公司服务层，默认会对数据过滤所属公司Company_id字段
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TViewEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TCreateDto"></typeparam>
    /// <typeparam name="TUpdateDto"></typeparam>
    /// <typeparam name="TQueryDto"></typeparam>
    public class AuditCompanyViewService<TEntity, TViewEntity, TDto, TCreateDto, TUpdateDto, TQueryDto>
        : AuditViewService<TEntity, TViewEntity, TDto, TCreateDto, TUpdateDto, TQueryDto>
        where TEntity : AuditCompanyEntity, new()
        where TViewEntity : AuditCompanyEntity, new()
        where TUpdateDto : IdEntityDto
        where TQueryDto : IQueryDto

    {
        public AuditCompanyViewService(ItSysDbContext dbContext, IMapper mapper, AuthContext authContext)
            : base(dbContext, mapper, authContext)
        {
            enableCompanyFilter = queryParams => true;
            companyFilterProp = e => e.company_id;
        }
    }
    public class AuditCompanyViewService<TEntity, TViewEntity, TDto, TSaveDto, TQueryDto>
        : AuditCompanyViewService<TEntity, TViewEntity, TDto, TSaveDto, TSaveDto, TQueryDto>
        where TEntity : AuditCompanyEntity, new()
        where TViewEntity : AuditCompanyEntity, new()
        where TSaveDto : IdEntityDto
        where TQueryDto : IQueryDto

    {
        public AuditCompanyViewService(ItSysDbContext dbContext, IMapper mapper, AuthContext authContext)
            : base(dbContext, mapper, authContext)
        { }
        public virtual TDto Save(TSaveDto saveDto)
        {
            if (saveDto.id == 0)
            {
                return Create(saveDto);
            }
            else
            {
                return Update(saveDto);
            }
        }
        public virtual TDto SaveWithTransaction(TSaveDto saveDto)
        {
            if (saveDto.id == 0)
            {
                return CreateWithTransaction(saveDto);
            }
            else
            {
                return UpdateWithTransaction(saveDto);
            }
        }
    }

    public class AuditCompanyViewService<TEntity, TViewEntity, TDto, TQueryDto>
        : AuditCompanyViewService<TEntity, TViewEntity, TDto, TDto, TQueryDto>
        where TEntity : AuditCompanyEntity, new()
        where TViewEntity : AuditCompanyEntity, new()
        where TDto : IdEntityDto
        where TQueryDto : IQueryDto

    {
        public AuditCompanyViewService(ItSysDbContext dbContext, IMapper mapper, AuthContext authContext)
            : base(dbContext, mapper, authContext)
        { }
    }
}
