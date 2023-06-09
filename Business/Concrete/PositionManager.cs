﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }

        public IResult Add(Position position)
        {
            _positionDal.Add(position);
            return new SuccessResult(Messages.AddPositionSuccess);
        }

        public IResult Delete(int id)
        {
            var position = GetById(id).Data;
            if (position == null)
            {
                return new ErrorResult(Messages.PositionNotFound);
            }

            _positionDal.Delete(position);
            return new SuccessResult(Messages.DeletePositionSuccess);
        }

        public IDataResult<List<Position>> GetAll()
        {
            var positions = _positionDal.GetAll();
            return new SuccessDataResult<List<Position>>(positions, Messages.GetPositionListSuccess);
        }

        public IDataResult<Position> GetById(int id)
        {
            var position = _positionDal.Get(p => p.PositionId == id);
            if (position == null)
            {
                return new ErrorDataResult<Position>(Messages.PositionNotFound);
            }

            return new SuccessDataResult<Position>(position, Messages.GetPositionSuccess);
        }

        public IResult Update(int id, Position position)
        {
            var currentPosition = _positionDal.Get(p => p.PositionId == id);
            if (currentPosition == null)
            {
                return new ErrorResult(Messages.PositionNotFound);
            }

            _positionDal.Update(position);
            return new SuccessResult(Messages.UpdatePositionSuccess);
        }
    }

}
